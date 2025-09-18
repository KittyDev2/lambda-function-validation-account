# KD.Function.Customer.ValidationAccounts Lambda Function

## Function Handler:
```bash
KD.Function.Customer.ValidationAccounts::KD.Function.Customer.ValidationAccounts.Function::FunctionHandler
```

## EventBridge schedule trigger cron expression:
```
cron(* */30 * * * *)
```
<small>A cada 30 minutos</small>

## EventBridge input:
```json
{}
```

## Executando o projeto localmente

1. Crie um arquivo `.env` na raiz do projeto `KD.Function.Customer.ValidationAccounts.RunLocal` e defina as variáveis de ambiente necessárias conforme especificado no arquivo [envs_map.txt](src/KD.Function.Customer.ValidationAccounts.RunLocal/envs_map.txt).

2. Execute o projeto `KD.Function.Product.RunLocal` (Console Application). As variáveis de ambiente do arquivo `.env` serão carregadas automaticamente e a função Lambda será executada localmente.