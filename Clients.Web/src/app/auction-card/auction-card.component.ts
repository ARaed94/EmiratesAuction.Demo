import { Component, OnInit, Input } from '@angular/core';
import { BaseComponent } from '../features/core/base/base.component';
import { LocalizationService } from '../features/core/localization/localization.service';
import { StorageService } from '../features/core/storage/storage.provider';

@Component({
  selector: 'auction-card',
  templateUrl: './auction-card.component.html',
  styleUrls: ['./auction-card.component.scss'],
})
export class AuctionCardComponent extends BaseComponent implements OnInit {
  @Input() auction;

  constructor(private localizationService: LocalizationService) {
    super();
  }

  ngOnInit() {
  }

  formatBid(bid) {
    return bid.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
  }
}
