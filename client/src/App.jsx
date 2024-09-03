
import { Routes, Route } from 'react-router-dom'
import './App.css'
import IndexPage from './pages/indexPage'
import LoginPage from './pages/LoginPage'
import Layout from './Layout'
import RegisterPage from './pages/RegisterPage'
import axios from 'axios'
import {UserContextProvider } from './UserContext'
import React from 'react'
import AccountPage from './pages/AccountPage'
import MeusEstudiosPage from './pages/MeusEstudiosPage'
import EstudiosFormPage from './pages/EstudiosFormPage'
import EstudiosPage from './pages/EstudiosPage'
import Agendamento from './pages/Agendamento'
import AgendamentoPage from './pages/AgendamentoPage'

axios.defaults.baseURL = 'http://localhost:5027/api'


function App() {


  return (
    <UserContextProvider>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<IndexPage />}/>
          <Route path='/login' element={<LoginPage />}/>
          <Route path='/register' element={<RegisterPage />}/>
          <Route path='/account/' element={<AccountPage />}/>
          <Route path='/account/estudios' element={<MeusEstudiosPage />}/>
          <Route path='/account/estudios/novo' element={<EstudiosFormPage />}/>
          <Route path='/account/estudios/:id' element={<EstudiosFormPage />}/>
          <Route path='/estudio/:id' element={<EstudiosPage />}/>
          <Route path='/account/agendamentos' element={<Agendamento />}/>
          <Route path='/account/agendamentos/:id' element={<AgendamentoPage />}/>
        </Route>
      </Routes>
    </UserContextProvider>
    
  )
}

export default App
