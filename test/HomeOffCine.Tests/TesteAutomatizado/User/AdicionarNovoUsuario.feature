Funcionalidade: User - Cadastrar novo usuario
	Como um visitante
	Eu desejo criar um novo usuario
	Para que eu possa acessar as demais funcionalidades

Cenário: Entrar na tela de cadastro de usuario
Dado Que o usuario acessou o site
Quando Ele clicar em cadastrar
Então O usuario será redirecionado para a tela com o formulario de cadastro

Cenário: Cadastrar novo usuario com sucesso
Dado Que o usuario acessou o site
Quando Ele clicar em cadastrar
E E Preencher os dados do formulario
		| Dados                |
		| E-mail               |
		| Senha                |
		| Confirmação da Senha |
E Clicar no botão cadastrar
Então O usuario será redirecionado para a Home
E Uma saudação com seu e-mail será exibida no menu superior