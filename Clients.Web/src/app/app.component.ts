import { Component } from '@angular/core';
import { MenuController, Platform } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';
import { LocalizationService } from './features/core/localization/localization.service';
import { BaseHttpService } from './features/core/http/base.http.service';
import { BaseComponent } from './features/core/base/base.component';
import { NotifyService } from './features/core/notify/notifiy.service';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss']
})
export class AppComponent extends BaseComponent {
  public makes: any[] = [];
  public models: any[] = [];
  public years: any[] = [];
  public criteria: any = {};
  public SwitchToLang: string;

  constructor(private platform: Platform, private splashScreen: SplashScreen,
    private statusBar: StatusBar, private localizationService: LocalizationService,
    private http: BaseHttpService, private menu: MenuController, private notify: NotifyService) {
    super();
    this.initializeApp();
  }

  initializeApp() {
    this.platform.ready().then(() => {
      this.statusBar.styleDefault();
      this.splashScreen.hide();

      // Load resources based on language.
      this.localizationService.setDefaultLanguage();
      let lang = this.localizationService.readAndSetLanguage();
      if (lang == "ar") {
        this.SwitchToLang = "English";
      }
      else {
        this.SwitchToLang = "العربية";
      }
      // Load filters.
      this.loadFilterData();
    });
  }

  loadFilterData() {
    this.http.get("makes").subscribe((response: any) => {
      if (response == null) {
        this.makes = [];
      }
      else {
        this.makes = response.body.result.data;
      }
    });
    this.http.get("models").subscribe((response: any) => {
      if (response == null) {
        this.models = [];
      }
      else {
        this.models = response.body.result.data;
      }
    });

    let currentYear = new Date().getFullYear();
    for (let index = 0; index < 40; index++) {
      this.years.push(currentYear - index);
    }
  }

  onMakeFilterSelect(event) {
    if (this.criteria == null) {
      this.criteria = {};
    }

    if (event.detail == null || event.detail.value == null) {
      return;
    }

    let id = event.detail.value;
    if (id != -1) {
      this.criteria.makeId = event.detail.value;
    }
    else {
      delete this.criteria.makeId;
    }
  }

  onModelFilterSelect(event) {
    if (this.criteria == null) {
      this.criteria = {};
    }

    if (event.detail == null || event.detail.value == null) {
      return;
    }

    let id = event.detail.value;
    if (id != -1) {
      this.criteria.modelId = event.detail.value;
    }
    else {
      delete this.criteria.modelId;
    }
  }

  onYearFilterSelect(event) {
    if (this.criteria == null) {
      this.criteria = {};
    }

    if (event.detail == null || event.detail.value == null) {
      return;
    }

    let id = event.detail.value;
    if (id != -1) {
      this.criteria.year = event.detail.value;
    }
    else {
      delete this.criteria.year;
    }
  }

  search() {
    this.menu.close();

    // pass crietria to home page and notify it.
    this.notify.sendCriteria(this.criteria);
  }

  resetData() {
    this.http.post("demo/reset-data").subscribe((_) => {
      this.menu.close();
      this.notify.sendCriteria(null);
    });
  }

  switchLang() {
    this.localizationService.toggleLanguage();
    let lang = this.localizationService.readAndSetLanguage();

    if (lang == "ar") {
      this.SwitchToLang = "English";
    }
    else {
      this.SwitchToLang = "العربية";
    }
  }
}
