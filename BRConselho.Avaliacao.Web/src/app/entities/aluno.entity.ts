import { Pessoa } from './pessoa.entity';

export interface Aluno {
  idPessoa?: number;
  dataNascimento?: Date;
  pessoa: Pessoa;
}
