import { Injectable, EventEmitter } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class LoadScreenService {
  static emitter: EventEmitter<boolean> = new EventEmitter<boolean>();

  get bind(): EventEmitter<boolean> {
    return LoadScreenService.emitter;
  }

  constructor() { }

  static start(): void {
    this.emitter.emit(true);
  }

  static stop(): void {
    this.emitter.emit(false);
  }
}
