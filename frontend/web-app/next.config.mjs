/** @type {import('next').NextConfig} */
const nextConfig = {
    logging: {
        fetches: {
            fullUrl: true
        }
    },
    images: {
        remotePatterns: [
            {
                protocol: 'https', hostname: 'cdn.pixabay.com', port: '',
                pathname: '/photo/**',
            }
        ]
    }
};

export default nextConfig;
