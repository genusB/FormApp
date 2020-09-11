<template>
  <div id="app" class="h-100">
    <nav class="navbar shadow bg-white rounded">
      <a class="navbar-brand flex-left"><img class="pr-3" alt="Plane logo" src="./assets/logo.png" width="50">Fly with us</a>
      <ul class="nav navbar-nav flex-row float-right">
        <li class="nav-item">
          <router-link class="nav-link pr-3" to="/">Form</router-link>
        </li>
        <li class="nav-item">
          <router-link class="btn btn-outline-dark" to="/search">Search</router-link>
        </li>
      </ul>
    </nav>
    
    <div class="container-fluid h-100 bg-body">
      <div class="row h-100 ">
        <div class="col-md-3 bg-plane h-100 d-flex justify-content-center align-items-center">
          <img alt="Plane logo" src="./assets/logo.png" width="100">
        </div>
        <div class="col-md-9 h-100 d-flex justify-content-center align-items-center">
          <div class="col-md-8 rounded px-5 py-4 shadow bg-white text-left">
            <router-view></router-view>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

export default {
  name: 'App',
}
</script>

<style>
#app {
  font-family: "Roboto", "Arial", "Helvetica Neue", sans-serif;

  text-align: center;
  color: #2c3e50;
}
.bg-body {
  background:  #C9F6FF;
}
.bg-plane {
  background: #7AE5F5;
}
.nav-link {
  color: #2c3e50 !important;
}
</style>
