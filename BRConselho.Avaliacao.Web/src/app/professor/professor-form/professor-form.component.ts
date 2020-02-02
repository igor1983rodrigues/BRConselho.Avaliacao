import { Subscription } from 'rxjs';
import { ProfessorService } from './../professor.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Professor } from './../../entities/professor.entity';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-professor-form',
  templateUrl: './professor-form.component.html',
  styleUrls: ['./professor-form.component.css']
})
export class ProfessorFormComponent extends BaseComponent<Professor> implements OnInit, OnDestroy {

  form: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private professorService: ProfessorService,
    private fb: FormBuilder,
    private router: Router
  ) {
    super();
  }

  ngOnInit() {
    this.isEdit = true;
    this.model = this.route.snapshot.data.professor as Professor;

    this.form = this.fb.group({
      nomePessoa: [this.model.nomePessoa, [Validators.required, Validators.maxLength(96)]],
    });

  }

  save(): void {
    delete (this.model as any).pessoa;
    this.model.nomePessoa = this.form.get('nomePessoa').value;
    if (!!this.model.idPessoa && this.model.idPessoa > 0) {
      this.update();
    } else {
      this.create();
    }
  }

  private create(): void {
    const insc: Subscription = this.professorService
      .post(this.model)
      .subscribe(
        res => this.resultCreateOrUpdate(res.message),
        error => console.error(error),
        () => insc.unsubscribe());
  }

  private resultCreateOrUpdate(message: string): void {
    alert(message);
    this.professorService.emmit.emit(true);
    this.voltar();
  }

  private update(): void {
    const insc: Subscription = this.professorService
      .put(this.model.idPessoa, this.model)
      .subscribe(
        res => this.resultCreateOrUpdate(res.message),
        error => console.error(error),
        () => insc.unsubscribe());
  }

  voltar(): void {
    this.router.navigate(['..'], { relativeTo: this.route });
  }

  ngOnDestroy(): void {
    this.isEdit = false;
  }
}
