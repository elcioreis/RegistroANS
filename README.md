# RegistroANS
Recebe um arquivo Excel com conteudo para registro de produto junto a ANS e gera um XML a ser enviado.

Atualmente funcionando para gerar arquivo RPI – Inclusão de prestadores na rede da operadora

Para a geração do arquivo RPI o Excel deverá conter a primeira planilha com as colunas preenchidas de A até S (19 colunas), a primeira linha será considerada cabeçalho

As colunas são as seguintes:
registroANS, cnpjOperadora, nossoNumero, isencaoOnus, classificacao, cnpjCpf, cnes, uf, codigoMunicipioIBGE, razaoSocial, relacaoOperadora, tipoContratualizacao, registroANSOperadoraIntermediaria, dataContratualizacao, dataInicioPrestacaoServico, disponibilidadeServic, urgenciaEmergencia, numeroRegistroPlanoVinculacao, codigoPlanoOperadoraVinculacao

Versão 0.0.0.1
	Inclusão de validação dos dados da RPI, incluindo cálculo de CNPJ e CPF