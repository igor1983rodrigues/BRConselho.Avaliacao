import { NgModule } from '@angular/core';

import { LoadScreenComponent } from './loadscreen.component';
import { LoadScreenService } from './loadscreen.service';

@NgModule({
  imports: [],
  declarations: [LoadScreenComponent],
  providers: [LoadScreenService],
  exports: [LoadScreenComponent],
})
export class LoadScreenModule { }
