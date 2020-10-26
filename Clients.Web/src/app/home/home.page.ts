import { Component, ViewChild } from '@angular/core';
import { IonInfiniteScroll } from '@ionic/angular';
import { Config } from '../config/config';
import { BaseComponent } from '../features/core/base/base.component';
import { BaseHttpService } from '../features/core/http/base.http.service';
import { NotifyService } from '../features/core/notify/notifiy.service';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage extends BaseComponent {
  public auctions: any[] = [];
  public loading: boolean = true;
  public criteria: any = {};
  public pagination: any = {};
  public serverTime: string;
  public clockRunning: boolean = false;

  @ViewChild(IonInfiniteScroll) infiniteScroll: IonInfiniteScroll;

  constructor(private http: BaseHttpService, private notify: NotifyService) {
    super();
    this.notify.notifier.subscribe((criteria: any) => {
      this.criteria = criteria || {};
      this.loadAuctions();
    });
  }

  ngOnInit() {
    this.pagination = { pageNumber: 1, pageSize: 10 }
    this.loadAuctions();
  }

  loadData() {
    return this.http.get("auctions", this.criteria, this.pagination);
  }

  loadAuctions() {
    this.loadData().subscribe((response: any) => {
      if (response == null) {
        this.auctions = [];
        this.loading = false;
      }
      else {
        this.auctions = response.body.result.data;
        this.pagination = response.body.result.pagination;
        this.serverTime = response.body.serverTime;

        this.loading = false;
        this.disableLoadMoreIfCompleted();

        if (this.clockRunning == false) {
          this.startCountdown();
        }
      }

      this.kickoffAutoRefresh();
    });
  }

  kickoffAutoRefresh() {
    if (Config.AutoRefreshEveryXSeconds != null) {
      let interval = setInterval(() => {
        this.pagination.pageNumber = 1;
        this.loadData().subscribe((response: any) => {
          if (response == null) {
            this.auctions = [];
            this.loading = false;
          }
          else {
            this.auctions = response.body.result.data;
            this.pagination = response.body.result.pagination;
            this.serverTime = response.body.serverTime;

            this.loading = false;
            this.disableLoadMoreIfCompleted();
          }
        });
      }, parseInt(Config.AutoRefreshEveryXSeconds) * 1000);
    }
  }

  refresh(event) {
    this.pagination.pageNumber = 1;
    this.loadData().subscribe((response: any) => {
      if (response == null) {
        this.auctions = [];
        event.target.complete();
      }
      else {
        this.auctions = response.body.result.data;
        this.pagination = response.body.result.pagination;
        this.serverTime = response.body.serverTime;

        event.target.complete();
        this.disableLoadMoreIfCompleted();
        if (this.clockRunning == false) {
          this.startCountdown();
        }
      }
    });
  }

  loadMore(event) {
    this.pagination.pageNumber = parseInt(this.pagination.pageNumber) + 1;
    this.loadData().subscribe((response: any) => {
      if (response == null) {
        event.target.complete();
      }
      else {
        this.auctions = this.auctions.concat(response.body.result.data);
        this.pagination = response.body.result.pagination;
        this.serverTime = response.body.serverTime;

        event.target.complete();
        this.disableLoadMoreIfCompleted();
        if (this.clockRunning == false) {
          this.startCountdown();
        }
      }
    });
  }

  disableLoadMoreIfCompleted() {
    if (this.pagination.pageNumber == this.pagination.totalPages) {
      this.infiniteScroll.disabled = true;
    }
  }


  startCountdown() {
    this.clockRunning = true;
    // Start date object with server time.
    let serverDate = new Date(this.serverTime);

    let counterInterval = setInterval(() => {

      this.auctions.forEach((auction: any) => {
        if (auction.endDateFormatted == null) {
          auction.endDateFormatted = new Date(auction.endDate);
        }

        serverDate = new Date(serverDate.getTime() + 100);
        let distance = auction.endDateFormatted.getTime() - serverDate.getTime();
        if (distance <= 0) {
          auction.timeLeft = "Expired";
        }
        else {
          let days = Math.floor(distance / (1000 * 60 * 60 * 24));
          let hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
          let minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
          let seconds = Math.floor((distance % (1000 * 60)) / 1000);
          auction.timeLeft = days + "d " + hours + "h " + minutes + "m " + seconds + "s ";
        }
        // 5 Mins.
        if (distance <= 300000) {
          auction.almostDone = "red";
        }
      });
    }, 1000);
  }
}