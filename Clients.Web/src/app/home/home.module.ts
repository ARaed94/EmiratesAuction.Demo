import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { FormsModule } from '@angular/forms';
import { HomePage } from './home.page';

import { HomePageRoutingModule } from './home-routing.module';
import { AuctionCardModule } from '../auction-card/auction-card.module';
import { BaseHttpService } from '../features/core/http/base.http.service';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    HomePageRoutingModule,
    AuctionCardModule,
    HttpClientModule
  ],
  declarations: [HomePage],
  providers:[BaseHttpService]
})
export class HomePageModule {}
