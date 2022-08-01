<template>
  <nav>
    <div class="text-center">
      <img class="mb-4" src="@/assets/image/logo.svg" alt="" width="72" height="72">
    </div>
    <router-link to="/">Login</router-link> |
    <router-link to="/Register">Register</router-link>
  </nav>

  <section style="height: 95%">
    <router-view />
  </section>

  <footer class="fixed-bottom">
    <div class="text-center">
      <p class="mt-5 mb-3 text-muted">© Kernel.Yang</p>
    </div>
  </footer>
</template>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}
</style>
