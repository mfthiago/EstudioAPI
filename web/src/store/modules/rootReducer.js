import {combineReducers} from 'redux'
import agendamento from './agendamento/reducer'
import clientes from './cliente/reducer'

export default combineReducers({
    agendamento,
    clientes,
});