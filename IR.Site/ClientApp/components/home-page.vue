<template>
    <div>
        <h1>Avaliação HBSIS</h1>
        <h2>Cenário</h2>
        <p>
            Digitar o CPF, nome do contribuinte, número de dependentes e renda bruta mensal de
            cada contribuinte.
        </p>
        <p>
            Após encerrar a entrada dos contribuintes, deve solicitar o valor do Salário Mínimo e
            então calcular e escrever o IR de cada contribuinte, em ordem crescente de valor de IR e
            ordem crescente de nome.
        </p>
        <p>
            <u>
                Regras para cálculo do IR do contribuinte:
            </u>
        </p>
        <p>
            Para cada contribuinte será concedido um desconto de 5% do valor Salário Mínimo por
            dependente. Os valores da alíquota para cálculo do imposto são:
        </p>
        
        <table style="width:100%">
            <tr>
                <th>Renda Líquida</th>
                <th>Alíquota</th>
            </tr>
            <tr>
                <td>até 2 salários mínimos</td>
                <td>isento</td>
            </tr>
            <tr>
                <td>acima de 2 até 4 salários mínimos</td>
                <td>7,5%</td>
            </tr>
            <tr>
                <td>acima de 4 até 5 salários mínimos</td>
                <td>15%</td>
            </tr>
            <tr>
                <td>acima de 5 até 7 salários mínimos</td>
                <td>22,5%</td>
            </tr>
            <tr>
                <td>acima de 7 salários mínimos</td>
                <td>27,5%</td>
            </tr>
        </table>
        <br>
        <p>
            <b>
                Renda Líquida = Renda Bruta - Descontos por Dependente;
            </b>
        </p>
        <h2>Requisitos</h2>
        <ul>
            <li>Os Contribuintes devem ser persistidos em um banco de dados.</li>
            <li>O frontend deve ser escrito em Javascript/html (framework JS fica a critério do desenvolvedor)</li>
            <li>Deve ser utilizado uma interface REST para se comunicar com o frontend (o framework de REST fica a critério do desenvolvedor)</li>
            <li>Para persistência dos dados deve ser utilizado algum framework de ORM, caso o banco escolhido seja NOSql desconsidere este requisito.</li>
            <li>Não é necessário editar/excluir.</li>
        </ul>
        <h2>Observações</h2>
        <ul>
            <li>O Backend deve ser escrito em .NET</li>
            <li>O Frontend deve ser escrito em HTML/JS</li>
            <li>Usabilidade, UX do frontend NÃO serão critérios avaliado.</li>
            <li>É obrigatório o uso de REST para resolver o problema.</li>
            <li>Testes unitários, divisão das camadas, modelagem, design patterns são fatores que serão levados em conta.</li>
        </ul>
    </div>
</template>

<script>
export default {
    data() {
        return {
        }
    },
}
</script>

<style>
    table, th, td {
        border: 1px solid black;
    }
</style>
