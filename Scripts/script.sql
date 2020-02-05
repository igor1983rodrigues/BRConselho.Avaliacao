-- Drop table

-- DROP TABLE public.tb_pessoa;

CREATE TABLE public.tb_pessoa (
	oid_pessoa serial NOT NULL,
	nome_pessoa varchar(96) NOT NULL,
	CONSTRAINT tb_pessoa_pkey PRIMARY KEY (oid_pessoa)
);

-- Drop table

-- DROP TABLE public.tb_aluno;

CREATE TABLE public.tb_aluno (
	oid_pessoa int4 NOT NULL,
	dt_nasc_aluno date NOT NULL,
	CONSTRAINT tb_aluno_pk PRIMARY KEY (oid_pessoa),
	CONSTRAINT tb_aluno_pessoa_fk FOREIGN KEY (oid_pessoa) REFERENCES tb_pessoa(oid_pessoa)
);

-- Drop table

-- DROP TABLE public.tb_professor;

CREATE TABLE public.tb_professor (
	oid_pessoa int4 NOT NULL,
	CONSTRAINT tb_professor_pk PRIMARY KEY (oid_pessoa),
	CONSTRAINT tb_professor_pessoa_fk FOREIGN KEY (oid_pessoa) REFERENCES tb_pessoa(oid_pessoa)
);

-- Drop table

-- DROP TABLE public.tb_aluno_professor;

CREATE TABLE public.tb_aluno_professor (
	oid_aluno int4 NOT NULL,
	oid_professor int4 NOT NULL,
	CONSTRAINT tb_aluno_professor_pk PRIMARY KEY (oid_aluno, oid_professor),
	CONSTRAINT tb_aluno_fk FOREIGN KEY (oid_aluno) REFERENCES tb_aluno(oid_pessoa),
	CONSTRAINT tb_professor_fk FOREIGN KEY (oid_professor) REFERENCES tb_professor(oid_pessoa)
);
