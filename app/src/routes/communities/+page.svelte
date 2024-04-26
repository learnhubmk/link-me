<script>
    import {onMount} from 'svelte';

    let communities;
    const loadCommunities = () => fetch('http://localhost:1337/api/communities').then(res => res.json());

    onMount(async () => {
        const response = await fetch('http://localhost:1337/api/communities');
        const data = await response.json();

        communities = data.data;
        console.log(communities);
    });
</script>

<div class="container p-6 mx-auto text-center bg-yellow-100 rounded mt-12 text-black">
    Example rendering communities from api:

    {#await loadCommunities()}
        <!-- promise is pending -->
        <p>waiting for the promise to resolve...</p>
    {:then data}
        <ul>
            {#each data.data as community}
                <li>{community.attributes.name} - {community.attributes.description}</li>
            {/each}
        </ul>
    {:catch error}
        <p>Something went wrong: {error.message}</p>
    {/await}
</div>