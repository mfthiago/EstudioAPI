import {BrowserRouter as Router,Route} from "react-router-dom";
import Agendamentos from './pages/Agendamentos';
import Clientes from './pages/Clientes';
import Header from "./components/Header";
import Sidebar from "./components/Sidebar";
import "./style.css";
import { Switch } from "react-router-dom/cjs/react-router-dom.min";


const Routes = () => {
    return (
        <>
            <Header />
            <div className="container-fluid h-100">
                <div className="row h-100">
                    <Router>
                    <Sidebar/>
                        <Switch>
                            <Route path="/" exact component={Agendamentos} />
                            <Route path="/clientes" exact component={Clientes} />
                        </Switch>
                    </Router>
                </div>
            </div>
        </>
    );
};

export default Routes;