import { takeLatest, all, call, put, select } from 'redux-saga/effects';
import { updateAgendamento } from './actions';
import types from './types';
import api from '../../../services/api';
import { notification } from '../../../services/rsuite';
import consts from '../../../consts';

export function* filterAgendamentos({ range }) {
  try {
    const { data: res } = yield call(api.post, '/agendamento', {
      estudioId: consts.estudioId,
      range,
    });

    if (res.error) {
      notification('error', {
        placement: 'topStart',
        title: 'Ops...',
        description: res.message,
      });
      return false;
    }
    
    yield put(updateAgendamento({ agendamentos: res.agendamentos }));

  } catch (err) {

    notification('error', {
      placement: 'topStart',
      title: 'Ops...',
      description: err.message,
    });
  }
}

export default all([takeLatest(types.FILTER_AGENDAMENTOS, filterAgendamentos)]);