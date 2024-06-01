<script>
	import '../app.css';
/* ne raboti 
	export default{
	data(){
		return{
			isOpen: false,
		}
	},
}
*/
</script>

<nav class="flex items-center justify-between flex-wrap bg-yellow-500 p-6">
	<div class="flex items-center flex-shrink-0 text-white mr-6">
	  <svg class="fill-current h-8 w-8 mr-2" width="54" height="54" viewBox="0 0 54 54" xmlns="http://www.w3.org/2000/svg"><path d="M13.5 22.1c1.8-7.2 6.3-10.8 13.5-10.8 10.8 0 12.15 8.1 17.55 9.45 3.6.9 6.75-.45 9.45-4.05-1.8 7.2-6.3 10.8-13.5 10.8-10.8 0-12.15-8.1-17.55-9.45-3.6-.9-6.75.45-9.45 4.05zM0 38.3c1.8-7.2 6.3-10.8 13.5-10.8 10.8 0 12.15 8.1 17.55 9.45 3.6.9 6.75-.45 9.45-4.05-1.8 7.2-6.3 10.8-13.5 10.8-10.8 0-12.15-8.1-17.55-9.45-3.6-.9-6.75.45-9.45 4.05z"/></svg>
	  <span class="font-semibold text-xl tracking-tight">Link-Me</span>
	</div>
	
	<div class="w-full block flex-grow lg:flex lg:items-center lg:w-auto">
	  <div class="text-sm lg:flex-grow">
		<a href="#responsive-header" class="block mt-4 lg:inline-block lg:mt-0 text-black-200 hover:text-white mr-4">
			Topics
		</a>
		<a href="/communities" class="block mt-4 lg:inline-block lg:mt-0 text-black-200 hover:text-white mr-4">
			Communities
		</a>
		<a href="#responsive-header" class="block mt-4 lg:inline-block lg:mt-0 text-black-200 hover:text-white mr-4">
		  Add Community
		</a>
		<a href="#responsive-header" class="block mt-4 lg:inline-block lg:mt-0 text-black-200 hover:text-white mr-4">
			Platforms
		  </a>
		  <a href="#responsive-header" class="block mt-4 lg:inline-block lg:mt-0 text-black-200 hover:text-white mr-4">
			Features
		  </a>
		  <a href="#responsive-header" class="block mt-4 lg:inline-block lg:mt-0 text-black-200 hover:text-white mr-4">
			Tools
		  </a>
		  <a href="#responsive-header" class="block mt-4 lg:inline-block lg:mt-0 text-black-200 hover:text-white mr-4">
			Blog
		  </a>
	  </div>
	  <div class="flex w-64 min-w-0 mr-5 bg-yellow-100 rounded">
		<input type="text" placeholder="Search or jump to..." size="30" class="h-8 w-full px-2 bg-transparent border-0 outline-none">
		
	  </div>
  
	</div>
	
	<div class="hidden">
		<button class="flex items-center px-3 py-2 border rounded text-teal-200 border-teal-400 hover:text-white hover:border-white">
		  <svg class="fill-current h-3 w-3" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg"><title>Menu</title><path d="M0 3h20v2H0V3zm0 6h20v2H0V9zm0 6h20v2H0v-2z"/></svg>
		</button>
	  </div>
  </nav>

<slot />


<style lang="postcss">
	:global(html) {
		background-color: theme(colors.white);
	}
</style>

