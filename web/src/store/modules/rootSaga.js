import {all} from 'redux-saga/effects';
import agendamento from './agendamento/sagas';
import clientes from './cliente/sagas';

export default function* rootSaga(){
    return yield all([agendamento,clientes]);
}