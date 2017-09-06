import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '../shared/shared.module';
import { AccountModule } from '../account/account.module';

import { TopMenuComponent } from './top-menu.component';
import { TopBarComponent } from './top-bar.component';
import { SearchBoxComponent } from '../search/search-box.component';

import { LocationService } from '../services/location.service';

@NgModule({
    imports: [
      CommonModule,
      SharedModule,
      AccountModule
    ],
    declarations: [
      TopMenuComponent,
      SearchBoxComponent,
      TopBarComponent
    ],
    exports: [
      TopBarComponent
    ],
    providers: [
      LocationService,
    ]
})
export class LayoutModule { }