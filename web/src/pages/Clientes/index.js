import { Table} from 'rsuite';
import {Button} from 'rsuite';
import {useDispatch, useSelector} from 'react-redux';
import { useState, useEffect } from 'react';
import { allClientes } from '../../store/modules/cliente/actions';


const { Column, Cell, HeaderCell } = Table;


const Clientes = () => {

    const dispatch = useDispatch();
    const{clientes} = useSelector((state)=>state.clientes);

    useEffect(()=>{
        dispatch(allClientes());
    }, []);


    return (
        <div className="col p-5 overflow-auto h-100">
            <div className="row">
                <div className="col-12">
                    <div className="w-100 d-flex justify-content-between">
                    <h2 className="mb-4 mt-0">Clientes</h2>
                        <div>
                            <button className="btn btn-primary btn-lg">
                                <span className="mdi mdi-plus">Novo Cliente</span>
                            </button>
                        </div>
                    </div>
                    <Table 
                        data={clientes} 
                        config={[
                            {label: 'Nome', key: 'nome', width: 200, fixed: true},
                            {label: 'E-mail', key: 'email', width: 200}, 
                            {label: 'Telefone', key: 'telefone', width: 200}, 
                        ]}
                        actions ={(cliente)=>(
                            <Button color="blue" size="xs">
                                Ver informações
                            </Button>
                        )}
                        onRowClick={(cliente)=>console.log(cliente)}
                    />
                </div> 

            </div>
        </div>
    );
};

export default Clientes;