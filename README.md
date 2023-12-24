# inoa_test
 Aplicação desenvolvida para o processo seletivo da Inoa.

# Orientações
 O programa deve ser executado via linha de comando seguindo o padrão ".\stock_quote_alert.exe petr4 36,2 25,98", onde, nesse caso "petr4" seria a ação consultada, "36,2" seria o preço de venda e "25,98" o preço de compra.

# Funcionamento
 O programa ira enviar um e-mail de 15 em 15 minutos, caso o preço da ação no mercado tenha ultrapassado os preços de venda ou compra (não realizando nada caso o que foi dito anteriormente não ocorra). O e-mail é enviado com base nas configurações do arquivo "config.json", e roda continuamente até ser interrompido ou, caso a configuração "oneTimeWarning" esteja como verdadeira, é interrompido depois de enviar um e-mail pela primeira vez.

 # Configurações
 No arquivo **Config.json**, há as configurações de execução do programa, que seguem abaixo:

 **"destinyEmails"**: Lista de strings contendo os e-mails de destino da mensagem gerada pela aplicação;

 **"password"**: String que contém a senha de acesso ao servidor SMTP que irá enviar o email;

 **port"**: Inteiro que contém a porta do servidor SMTP;

 **"smtpHost"**: String que corresponde ao servidor SMTP utilizado;

 **"userName"**: String que contém o username (normalmente, o e-mail) de acesso ao servidor SMTP que irá enviar o email;

 **"oneTimeWarning"**: Booleano que indica se a aplicação deve se encerrar depois de enviar o primeiro e-mail;

 # Considerações finais
  Programa realizado para o processo seletivo da Inoa, criado por Mateus Olaso. De imediato, agradeço a oportunidade oferecida pela empresa.
