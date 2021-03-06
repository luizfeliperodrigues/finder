# Finder
Finder é uma solução ConsoleApp para encontrar restaurantes disponíveis, dado uma hora especificada e um arquivo CSV com todos restaurantes cadastrados.

O nome Finder se dá pelo fato da aplicação poder expandir para encontrar outros tipos de estabelecimentos, assim como encontrar outros tipos de disponibilidades.

A arquitetura utilizada foi DDD para que a solução seja o menos acoplada possível e que sua manutenção e escalabilidade se tornem viáveis.

A solução possui 3 camadas: Domain, Application Services e ConsoleApp.

### Domain
Camada responsável pelas regras de negocio da aplicação, que nesse caso é representado pela classe Restaurant e os serviços que aquele restaurante pode oferecer, implementando a interface IRestaurantService.

### Application Services
Camada responsável pela intermediação entre Domain e ConsoleApp.

Ela é responsável por tratar os dados de input, como leitura de CSV e parsear hora para comunicação com o Domain.

E como resposta para o input, trata os dados do domain para uma lista de string, como resposta ao usuário.

Foi feita a leitura dos arquivos CSV com a ajuda da biblioteca CsvHelper.

### ConsoleApp
Seria a camada responsável pela comunicação usuário ou aplicação que possa consumir Finder.

Responsável por validação dos dados de entrada e também pela padronização de resposta quando o caminho ótimo é seguido.

No folder CSV Demo há alguns exemplos de arquivos csv, sendo o "restaurant-hours.csv" o padrão para o caminho ótimo da aplicação e os outros para verificação de performance ou csv's corrompidos para tratamento de erros.

### Referencias
.Net Core v3.1

CsvHelper v15.0.5

XUnit v2.4.0

FluentAssertions v5.10.3
