import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { faCalendar } from '@fortawesome/free-solid-svg-icons';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbCalendar, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';

import { Aluno } from './../../entities/aluno.entity';
import { AlunoService } from './../aluno.service';

@Component({
  selector: 'app-aluno-form',
  templateUrl: './aluno-form.component.html',
  styleUrls: ['./aluno-form.component.css']
})
export class AlunoFormComponent implements OnInit, OnDestroy {
  model: Aluno;
  faCalendar = faCalendar;
  form: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private alunoService: AlunoService,
    private fb: FormBuilder
  ) {
    this.model = { pessoa: {} };
  }

  ngOnInit() {
    // const insc: Subscription = this.route.params
    //   .pipe(
    //     map(({ id }) => id),
    //     switchMap(id => this.alunoService.getById(id))
    //   ).subscribe(
    //     res => this.model = res,
    //     error => console.error(error),
    //     () => insc.unsubscribe()
    //   );

    this.model = this.route.snapshot.data.aluno;
    this.form = this.fb.group({
      nomePessoa: [this.model.pessoa.nomePessoa, [Validators.required, Validators.maxLength(96)]],
      dataNascimento: [this.model.dataNascimento || Date.now.toString(), Validators.required]
    });

  }

  save(): void {
    debugger;

    const d: { year, month, day } = this.form.get('dataNascimento').value;
    this.model.pessoa.nomePessoa = this.form.get('nomePessoa').value;
    this.model.dataNascimento = new Date(d.year, d.month, d.day);

    if (!!this.model.idPessoa && this.model.idPessoa > 0) {
      this.update();
    } else {
      this.create();
    }
  }

  private create(): void {
    const insc: Subscription = this.alunoService
      .post(this.model)
      .subscribe(
        res => alert('alterado'),
        error => console.error(error),
        () => insc.unsubscribe());
  }

  private update(): void {
    const insc: Subscription = this.alunoService
      .put(this.model.idPessoa, this.model)
      .subscribe(
        res => alert('alterado'),
        error => console.error(error),
        () => insc.unsubscribe());
  }

  ngOnDestroy(): void {
  }
}
