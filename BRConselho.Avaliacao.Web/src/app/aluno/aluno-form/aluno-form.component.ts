import { Aluno } from './../../entities/aluno.entity';
import { AlunoService } from './../aluno.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import {faCalendar} from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-aluno-form',
  templateUrl: './aluno-form.component.html',
  styleUrls: ['./aluno-form.component.css']
})
export class AlunoFormComponent implements OnInit, OnDestroy {
  model: Aluno;
  faCalendar = faCalendar;

  constructor(
    private route: ActivatedRoute,
    private alunoService: AlunoService
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
  }

  save(): void {
    if (!!this.model.idPessoa && this.model.idPessoa > 0) {
      this.alunoService.put(this.model.idPessoa, this.model);
    } else {
      this.alunoService.post(this.model);
    }
  }

  ngOnDestroy(): void {
  }
}
