import { Pessoa } from './pessoa.entity';

export interface Aluno extends Pessoa {
  dataNascimentoAluno?: Date;
}
