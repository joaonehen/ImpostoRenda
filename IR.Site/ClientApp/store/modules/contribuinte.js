import api from '../api'

const actions = {
    inserirContribuinte({ commit }, contribuinte) {
        return new Promise((resolve, reject) => {
            api.post('/Contribuinte/Incluir', contribuinte).then((success) => {
                resolve(success.result);
            }, (error) => {
                reject(error)
            })
        })
    },
    calcularImpostoRenda({ commit }, salarioMinimo) {
        return new Promise((resolve, reject) => {
            api.get('/Contribuinte/CalcularImpostoRenda', { salarioMinimo : salarioMinimo}).then((success) => {
                resolve(success.data);
            }, (error) => {
                reject(error)
            })
        })
    }
}

export default {
    actions
}
