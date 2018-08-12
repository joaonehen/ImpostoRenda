<template>
    <div>
        <h1> Calculo de Imposto de Renda</h1>
        <div v-if="resultados.length==0">
            <div class="form-group">
                <label for="salarioMinimo">Salário Mínimo</label>
                <input type="number" v-model="salarioMinimo" min="1" step="0.01" data-number-to-fixed="2" data-number-stepfactor="100"  class="form-control" id="rendaBrutaMensal" placeholder="Informe a renda bruta mensal"></input>
            </div>
            <button type="button" class="btn btn-success" @click="Calcular">Calcular</button>
        </div>
        <div v-else>
            <table class="table table-condensed">
                <thead>
                    <tr>
                        <th>CPF</th>
                        <th>Nome</th>
                        <th>Numero Dependentes</th>
                        <th>Renda Bruta Mensal</th>
                        <th>Valor Imposto Renda</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="resultado in resultados">
                        <td>{{resultado.cpf}}</td>
                        <td>{{resultado.nome}}</td>
                        <td>{{resultado.numeroDependentes}}</td>
                        <td>{{resultado.rendaBrutaMensal}}</td>
                        <td>{{resultado.valorImpostoRenda}}</td>
                    </tr>
                </tbody>
            </table>
            <button type="button" class="btn btn-success" @click="LimparTabela">Limpar</button>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            salarioMinimo:954,
            resultados:[]
        }
    },
    methods:{
        Calcular(){
            this.LimparTabela();
            this.$store.dispatch('calcularImpostoRenda', this.salarioMinimo).then((success) => {
                this.resultados = success;
            });
        },
        LimparTabela(){
            this.resultados=[];
        }
    }
}
</script>

<style>
</style>
