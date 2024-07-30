import {takeLatest, all,call,put,select} from 'redux-saga/effects';
import {updateCliente} from './actions'
import types from './types';
import api from '../../../services/api';
import consts from '../../../consts';

export function* allClientes(){
    try{
        const {data : res} = yield call(
          api.get, 
          `/account/`);
        if(res.error){
          alert(res.message);
          return false
        }

        yield put(updateCliente({clientes: res.clientes}));

    }catch(err){
        alert(err.message)
    }
}

export default all([takeLatest(types.ALL_CLIENTES, allClientes)]);