# RegistroANS
Recebe um arquivo Excel com conteudo para registro de produto junto a ANS e gera um XML a ser enviado.

Versão 0.0.0.1 - Funcionando para gerar arquivo RPI – Inclusão de prestadores na rede da operadora
Versão 0.0.0.2 - Funcionando para gerar arquivo RPE - Exclusão de prestadores na rede da operadora
Versão 0.0.0.3 - Ajustes na geração de arquivo RPI para gerar campos nulos quando permitido
				 Ajustes no arquivo Schema RPI para criticar campo razaoSocial maior que o permitido
				 Ajustes no arquivo Schema RPI para criticar campo dataInicioPrestacaoServico nulo


Notas sobre arquivos RPI de entrada (arquivo Excel)
	Para a geração do arquivo RPI o Excel deverá conter a primeira planilha com as colunas preenchidas de A até S 
	(19 colunas), a primeira linha será considerada cabeçalho

	As colunas são as seguintes:
	registroANS, cnpjOperadora, nossoNumero, isencaoOnus, classificacao, cnpjCpf, cnes, uf, 
	codigoMunicipioIBGE, razaoSocial, relacaoOperadora, tipoContratualizacao, 
	registroANSOperadoraIntermediaria, dataContratualizacao, 	dataInicioPrestacaoServico,
	disponibilidadeServic, urgenciaEmergencia, numeroRegistroPlanoVinculacao, 
	codigoPlanoOperadoraVinculacao

Notas sobre arquivos RPE de entrada (arquivo Excel)
	Para a geração do arquivo RPE o Excel deverá conter a primeira planilha com as colunas preenchidas de A até E 
	(5 colunas), a primeira linha será considerada cabeçalho

	As colunas são as seguintes:
	registroANS, cnpjOperadora, cnpjCpf, cnes, codigoMunicipioIBGE