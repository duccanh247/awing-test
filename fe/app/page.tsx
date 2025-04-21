import Image from "next/image";

export default function Home() {
  return (
    <div className="grid grid-rows-[20px_1fr_20px] items-center justify-items-center min-h-screen p-8 pb-20 gap-16 sm:p-20 font-[family-name:var(--font-geist-sans)]">
      <main className="flex flex-col gap-[32px] row-start-2 items-center  ">
        <h1 className="text-6xl">Welcome to Awing</h1>
        <Image
          className="dark:invert"
          src="/wing.png"
          alt="Awing"
          width={380}
          height={200}
          priority
        />
      </main>
    </div>
  );
}
