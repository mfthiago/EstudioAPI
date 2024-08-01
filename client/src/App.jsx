
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

axios.defaults.baseURL = 'http://localhost:5027/api'


function App() {


  return (
    <UserContextProvider>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<IndexPage />}/>
          <Route path='/login' element={<LoginPage />}/>
          <Route path='/register' element={<RegisterPage />}/>
          <Route path='/account/:subpage?' element={<AccountPage />}/>
          <Route path='/account/:subpage/:action' element={<AccountPage />}/>
        </Route>
      </Routes>
    </UserContextProvider>
    
  )
}

export default App
