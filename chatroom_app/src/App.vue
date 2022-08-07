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
