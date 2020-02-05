import { Subscription } from 'rxjs';
import { Component, OnInit, OnDestroy } from '@angular/core';

import { LoadScreenService } from './loadscreen.service';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'load-screen',
  styleUrls: ['./loadscreen.component.css'],
  templateUrl: './loadscreen.component.html'
})

export class LoadScreenComponent implements OnInit, OnDestroy {
  show: boolean;
  inscricao: Subscription;

  constructor(private loadScreenService: LoadScreenService) { }

  ngOnInit() {
    this.inscricao = this.loadScreenService.bind.subscribe(res => {
      this.show = res;
    });

    this.loadScreenService.bind.emit(false);
  }

  ngOnDestroy(): void {
    this.inscricao.unsubscribe();
  }
}
