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
    
    <div class="container-fluid bg-body">
      <div class="row">
        <div class="col-md-10 d-flex justify-content-center align-items-center mx-auto">
          <router-view></router-view>
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
