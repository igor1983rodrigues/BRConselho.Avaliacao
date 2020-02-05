import { Pessoa } from './pessoa.entity';
import { Professor } from './professor.entity';

export interface Aluno extends Pessoa {
  dataNascimentoAluno?: Date;
  professor?: Professor;
}
