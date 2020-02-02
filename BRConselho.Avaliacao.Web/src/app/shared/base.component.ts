import { Component, OnInit, OnDestroy } from '@angular/core';

export class BaseComponent<T> implements OnInit, OnDestroy {
  model: T;
  private static _isEdit = false;

  get isEdit() {
    return  BaseComponent._isEdit;
  }

  set isEdit(isEdit: boolean) {
    BaseComponent._isEdit = isEdit;
  }

  constructor() {
    this.model = {} as T;
  }

  ngOnInit(): void { }

  ngOnDestroy(): void {
  }
}
