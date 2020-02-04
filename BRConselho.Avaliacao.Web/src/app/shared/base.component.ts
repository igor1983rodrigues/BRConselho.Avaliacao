import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

export class BaseComponent<T> implements OnInit, OnDestroy {
  // tslint:disable-next-line: variable-name
  private static _isEdit = false;
  model: T;

  get isEdit() {
    return BaseComponent._isEdit;
  }

  set isEdit(isEdit: boolean) {
    BaseComponent._isEdit = isEdit;
  }

  constructor(
    protected router: Router,
    protected route: ActivatedRoute
  ) {
    this.model = {} as T;
  }

  ngOnInit(): void { }

  voltar(level = 1): void {
    const arr: string[] = [];
    for (; level > 0; level--) {
      arr.push('..');
    }
    this.router.navigate(arr, { relativeTo: this.route });
  }

  ngOnDestroy(): void {
  }
}
