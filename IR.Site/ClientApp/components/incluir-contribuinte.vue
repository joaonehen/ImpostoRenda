<template>
    <div>
        <bootstrap-modal ref="modalSucesso" :need-header="true" :need-footer="false" :size="'large'" :opened="ModalOpened">
            <div slot="title">
                Mensagem de Sucesso.
            </div>
            <div slot="body">
                O Contribuinte foi incluído com sucesso.
            </div>
            <div slot="footer">
                Your footer here
            </div>
        </bootstrap-modal>
        <h1> Inclusão de Contribuinte</h1>
        <div class="form-group" :class="{ 'has-error' : erros.CPF.length > 0 }">
            <label for="cpf">CPF</label>
            <input type="text" v-model="contribuinte.CPF" class="form-control" id="cpf" placeholder="Informe o CPF do contribuinte"></input>
            <span v-for="erro in erros.CPF" class="help-block">{{erro}}</span>
        </div>
        <div class="form-group" :class="{ 'has-error' : erros.Nome.length > 0 }">
            <label for="nome">Nome</label>
            <input type="text" v-model="contribuinte.Nome" class="form-control" id="nome" placeholder="Informe o Nome do contribuinte"></input>
            <span v-for="erro in erros.Nome" class="help-block">{{erro}}</span>
        </div>
        <div class="form-group" :class="{ 'has-error' : erros.NumeroDependentes.length > 0 }">
            <label for="numeroDependentes">Numero Dependentes</label>
            <input type="number" v-model="contribuinte.NumeroDependentes" min="0" step="1" class="form-control" id="numeroDependentes" placeholder="Informe o numero de dependentes"></input>
            <span v-for="erro in erros.NumeroDependentes" class="help-block">{{erro}}</span>
        </div>
        <div class="form-group" :class="{ 'has-error' : erros.RendaBrutaMensal.length > 0 }">
            <label for="rendaBrutaMensal">Renda Bruta Mensal</label>
            <input type="number" v-model="contribuinte.RendaBrutaMensal" min="0" step="0.01" data-number-to-fixed="2" data-number-stepfactor="100"  class="form-control" id="rendaBrutaMensal" placeholder="Informe a renda bruta mensal"></input>
            <span v-for="erro in erros.RendaBrutaMensal" class="help-block">{{erro}}</span>
        </div>
        <button type="button" class="btn btn-success" @click="Inserir">Inserir</button>
        <button type="button" class="btn btn-warning" @click="Limpar">Limpar</button>
    </div>
</template>

<script>
export default {
    components: {
        'bootstrap-modal': require('vue2-bootstrap-modal')
    },
    data() {
        return {
            contribuinte:{
                CPF:'',
                Nome:'',
                NumeroDependentes:0,
                RendaBrutaMensal:0
            },
            erros:{
                CPF:[],
                Nome:[],
                NumeroDependentes:[],
                RendaBrutaMensal:[]
            },
        }
    },
    methods:{
        Inserir(){
            this.LimparErros();
            this.$store.dispatch('inserirContribuinte', this.contribuinte).then((success) => {
                this.$refs.modalSucesso.open();
                this.Limpar();
            }, (error) => {
                for (var name in error.errors) {
                    var erro = error.errors[name];
                    this.erros[erro.key].push(erro.value);
                }
            });
        },
        Limpar(){
            this.LimparErros();
            this.contribuinte =
            {
                CPF:'',
                Nome:'',
                NumeroDependentes:0,
                RendaBrutaMensal:0
            }
        },
        LimparErros(){
            for (var name in this.erros) {
                this.erros[name] = [];
            }
        },
        ModalOpened(){
            var self = this;
            setTimeout(function(){ self.$refs.modalSucesso.close(); }, 3000);
        }
    }
}
</script>

<style>
</style>
