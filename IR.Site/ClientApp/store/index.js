import Vue from 'vue'
import Vuex from 'vuex'
import contribuinte from './modules/contribuinte';

Vue.use(Vuex)

export default new Vuex.Store({
    modules: {
        contribuinte
    }
});
