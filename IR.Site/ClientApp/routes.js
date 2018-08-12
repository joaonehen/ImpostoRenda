import Home from 'components/home-page'
import CalcularImpostoRenda from 'components/calcular-imposto-renda'
import IncluirContribuinte from 'components/incluir-contribuinte'

export const routes = [
    { path: '/', component: Home, display: 'Home', style: 'glyphicon glyphicon-home' },
    { path: '/incluir-contribuinte', component: IncluirContribuinte, display: 'Incluir Contribuinte', style: 'glyphicon glyphicon-plus' },
    { path: '/calcular-imposto-renda', component: CalcularImpostoRenda, display: 'Calcular Imposto Renda', style: 'glyphicon glyphicon-briefcase' },
]
