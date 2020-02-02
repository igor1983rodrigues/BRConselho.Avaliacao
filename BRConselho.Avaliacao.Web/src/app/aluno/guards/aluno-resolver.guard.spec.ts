import { TestBed, async, inject } from '@angular/core/testing';

import { AlunoResolverGuard } from './aluno-resolver.guard';

describe('AlunoResolverGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AlunoResolverGuard]
    });
  });

  it('should ...', inject([AlunoResolverGuard], (guard: AlunoResolverGuard) => {
    expect(guard).toBeTruthy();
  }));
});
