Funcionalidade: User - Login
	Como um usuario
	Eu desejo me logar na aplicação
	Para que eu possa acessar as demais funcionalidades

Cenario: Entrar na tela de login
Dado Que o usuario acessou o site
Quando Ele clicar em login
Então O usuario será redirecionado para a tela de login

Cenário: Logar na aplicação
Dado Que o usuario acessou o site
Quando Ele clicar em login
E O usuario preencher o formulario
			| Dados  |
			| E-mail |
			| Senha  |
E Ele clicar em logar
Então Uma saudação com seu e-mail será exibida no menu superior