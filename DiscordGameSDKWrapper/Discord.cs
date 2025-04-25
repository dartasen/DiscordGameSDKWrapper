using System;
using System.Runtime.InteropServices;

namespace DiscordGameSDKWrapper;

public partial class Discord : IDisposable
{
    [StructLayout(LayoutKind.Sequential)]
    internal partial struct FFIEvents
    {

    }

    [StructLayout(LayoutKind.Sequential)]
    internal partial struct FFIMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DestroyHandler(IntPtr MethodsPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Result RunCallbacksMethod(IntPtr methodsPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SetLogHookCallback(IntPtr ptr, LogLevel level, [MarshalAs(UnmanagedType.LPStr)] string message);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SetLogHookMethod(IntPtr methodsPtr, LogLevel minLevel, IntPtr callbackData, SetLogHookCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr GetApplicationManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr GetUserManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr GetImageManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr GetActivityManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr GetRelationshipManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr GetLobbyManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr GetNetworkManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr GetOverlayManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr GetStorageManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr GetStoreManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr GetVoiceManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr GetAchievementManagerMethod(IntPtr discordPtr);

        internal DestroyHandler Destroy;

        internal RunCallbacksMethod RunCallbacks;

        internal SetLogHookMethod SetLogHook;

        internal GetApplicationManagerMethod GetApplicationManager;

        internal GetUserManagerMethod GetUserManager;

        internal GetImageManagerMethod GetImageManager;

        internal GetActivityManagerMethod GetActivityManager;

        internal GetRelationshipManagerMethod GetRelationshipManager;

        internal GetLobbyManagerMethod GetLobbyManager;

        internal GetNetworkManagerMethod GetNetworkManager;

        internal GetOverlayManagerMethod GetOverlayManager;

        internal GetStorageManagerMethod GetStorageManager;

        internal GetStoreManagerMethod GetStoreManager;

        internal GetVoiceManagerMethod GetVoiceManager;

        internal GetAchievementManagerMethod GetAchievementManager;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal partial struct FFICreateParams
    {
        internal long ClientId;

        internal ulong Flags;

        internal IntPtr Events;

        internal IntPtr EventData;

        internal IntPtr ApplicationEvents;

        internal uint ApplicationVersion;

        internal IntPtr UserEvents;

        internal uint UserVersion;

        internal IntPtr ImageEvents;

        internal uint ImageVersion;

        internal IntPtr ActivityEvents;

        internal uint ActivityVersion;

        internal IntPtr RelationshipEvents;

        internal uint RelationshipVersion;

        internal IntPtr LobbyEvents;

        internal uint LobbyVersion;

        internal IntPtr NetworkEvents;

        internal uint NetworkVersion;

        internal IntPtr OverlayEvents;

        internal uint OverlayVersion;

        internal IntPtr StorageEvents;

        internal uint StorageVersion;

        internal IntPtr StoreEvents;

        internal uint StoreVersion;

        internal IntPtr VoiceEvents;

        internal uint VoiceVersion;

        internal IntPtr AchievementEvents;

        internal uint AchievementVersion;
    }

#if NET8_0_OR_GREATER
    [LibraryImport(Constants.DllName)]
    internal static partial Result DiscordCreate(uint version, ref FFICreateParams createParams, out IntPtr manager);
#elif NETFRAMEWORK

    private static Lazy<IntPtr> libDiscordHandle = new(() => LibraryLoader.LoadLocalLibrary<Discord>(Constants.DllName));

    private partial class Delegates
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Result DiscordCreate(uint version, ref FFICreateParams createParams, out IntPtr manager);
    }

    private static Delegates.DiscordCreate discord_create_delegate;
    internal static Result DiscordCreate(uint version, ref FFICreateParams createParams, out IntPtr manager) =>
        (discord_create_delegate ??= LibraryLoader.GetSymbolDelegate<Delegates.DiscordCreate>(libDiscordHandle.Value, "DiscordCreate")).Invoke(version, ref createParams, out manager);
#else
    [DllImport(Constants.DllName, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
    internal static extern Result DiscordCreate(uint version, ref FFICreateParams createParams, out IntPtr manager);
#endif

    public delegate void SetLogHookHandler(LogLevel level, string message);

    private GCHandle SelfHandle;

    private IntPtr EventsPtr;

    private FFIEvents Events;

    private IntPtr ApplicationEventsPtr;

    private ApplicationManager.FFIEvents ApplicationEvents;

    internal ApplicationManager ApplicationManagerInstance;

    private IntPtr UserEventsPtr;

    private UserManager.FFIEvents UserEvents;

    internal UserManager UserManagerInstance;

    private IntPtr ImageEventsPtr;

    private ImageManager.FFIEvents ImageEvents;

    internal ImageManager ImageManagerInstance;

    private IntPtr ActivityEventsPtr;

    private ActivityManager.FFIEvents ActivityEvents;

    internal ActivityManager ActivityManagerInstance;

    private IntPtr RelationshipEventsPtr;

    private RelationshipManager.FFIEvents RelationshipEvents;

    internal RelationshipManager RelationshipManagerInstance;

    private IntPtr LobbyEventsPtr;

    private LobbyManager.FFIEvents LobbyEvents;

    internal LobbyManager LobbyManagerInstance;

    private IntPtr NetworkEventsPtr;

    private NetworkManager.FFIEvents NetworkEvents;

    internal NetworkManager NetworkManagerInstance;

    private IntPtr OverlayEventsPtr;

    private OverlayManager.FFIEvents OverlayEvents;

    internal OverlayManager OverlayManagerInstance;

    private IntPtr StorageEventsPtr;

    private StorageManager.FFIEvents StorageEvents;

    internal StorageManager StorageManagerInstance;

    private IntPtr StoreEventsPtr;

    private StoreManager.FFIEvents StoreEvents;

    internal StoreManager StoreManagerInstance;

    private IntPtr VoiceEventsPtr;

    private VoiceManager.FFIEvents VoiceEvents;

    internal VoiceManager VoiceManagerInstance;

    private IntPtr AchievementEventsPtr;

    private AchievementManager.FFIEvents AchievementEvents;

    internal AchievementManager AchievementManagerInstance;

    private IntPtr MethodsPtr;

    private object MethodsStructure;

    private FFIMethods Methods
    {
        get
        {
            MethodsStructure ??= Marshal.PtrToStructure<FFIMethods>(MethodsPtr);
            return (FFIMethods)MethodsStructure;
        }

    }

    private GCHandle? setLogHook;

    public Discord(long clientId, CreateFlags flags) : this(clientId, (ulong)flags)
    {

    }

    public Discord(long clientId, ulong flags)
    {
        FFICreateParams createParams;
        createParams.ClientId = clientId;
        createParams.Flags = flags;
        Events = new FFIEvents();
        EventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(Events));
        createParams.Events = EventsPtr;
        SelfHandle = GCHandle.Alloc(this);
        createParams.EventData = GCHandle.ToIntPtr(SelfHandle);
        ApplicationEvents = new ApplicationManager.FFIEvents();
        ApplicationEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(ApplicationEvents));
        createParams.ApplicationEvents = ApplicationEventsPtr;
        createParams.ApplicationVersion = 1;
        UserEvents = new UserManager.FFIEvents();
        UserEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(UserEvents));
        createParams.UserEvents = UserEventsPtr;
        createParams.UserVersion = 1;
        ImageEvents = new ImageManager.FFIEvents();
        ImageEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(ImageEvents));
        createParams.ImageEvents = ImageEventsPtr;
        createParams.ImageVersion = 1;
        ActivityEvents = new ActivityManager.FFIEvents();
        ActivityEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(ActivityEvents));
        createParams.ActivityEvents = ActivityEventsPtr;
        createParams.ActivityVersion = 1;
        RelationshipEvents = new RelationshipManager.FFIEvents();
        RelationshipEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(RelationshipEvents));
        createParams.RelationshipEvents = RelationshipEventsPtr;
        createParams.RelationshipVersion = 1;
        LobbyEvents = new LobbyManager.FFIEvents();
        LobbyEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(LobbyEvents));
        createParams.LobbyEvents = LobbyEventsPtr;
        createParams.LobbyVersion = 1;
        NetworkEvents = new NetworkManager.FFIEvents();
        NetworkEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(NetworkEvents));
        createParams.NetworkEvents = NetworkEventsPtr;
        createParams.NetworkVersion = 1;
        OverlayEvents = new OverlayManager.FFIEvents();
        OverlayEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(OverlayEvents));
        createParams.OverlayEvents = OverlayEventsPtr;
        createParams.OverlayVersion = 2;
        StorageEvents = new StorageManager.FFIEvents();
        StorageEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(StorageEvents));
        createParams.StorageEvents = StorageEventsPtr;
        createParams.StorageVersion = 1;
        StoreEvents = new StoreManager.FFIEvents();
        StoreEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(StoreEvents));
        createParams.StoreEvents = StoreEventsPtr;
        createParams.StoreVersion = 1;
        VoiceEvents = new VoiceManager.FFIEvents();
        VoiceEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(VoiceEvents));
        createParams.VoiceEvents = VoiceEventsPtr;
        createParams.VoiceVersion = 1;
        AchievementEvents = new AchievementManager.FFIEvents();
        AchievementEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(AchievementEvents));
        createParams.AchievementEvents = AchievementEventsPtr;
        createParams.AchievementVersion = 1;
        InitEvents(EventsPtr, ref Events);
        Result result = DiscordCreate(3, ref createParams, out MethodsPtr);
        if (result != Result.Ok)
        {
            Dispose();
            throw new ResultException(result);
        }
    }

    private static void InitEvents(IntPtr eventsPtr, ref FFIEvents events)
    {
        Marshal.StructureToPtr(events, eventsPtr, false);
    }

    public void Dispose()
    {
        if (MethodsPtr != IntPtr.Zero)
        {
            Methods.Destroy(MethodsPtr);
        }

        if (SelfHandle.IsAllocated)
        {
            SelfHandle.Free();
        }

#if NETFRAMEWORK
        if (libDiscordHandle.IsValueCreated)
        {
            LibraryLoader.FreeLibrary(libDiscordHandle.Value);
            libDiscordHandle = new(() => LibraryLoader.LoadLocalLibrary<Discord>(Constants.DllName));
        }

        discord_create_delegate = null;
#endif

        if (EventsPtr != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(EventsPtr);
        }

        if (ApplicationEventsPtr != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(ApplicationEventsPtr);
        }

        if (UserEventsPtr != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(UserEventsPtr);
        }

        if (ImageEventsPtr != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(ImageEventsPtr);
        }

        if (ActivityEventsPtr != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(ActivityEventsPtr);
        }

        if (ActivityEventsPtr != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(RelationshipEventsPtr);
        }

        if (ActivityEventsPtr != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(LobbyEventsPtr);
        }

        if (ActivityEventsPtr != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(NetworkEventsPtr);
        }

        if (ActivityEventsPtr != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(OverlayEventsPtr);
        }

        if (ActivityEventsPtr != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(StorageEventsPtr);
        }

        if (ActivityEventsPtr != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(StoreEventsPtr);
        }

        if (ActivityEventsPtr != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(VoiceEventsPtr);
        }

        if (ActivityEventsPtr != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(AchievementEventsPtr);
        }

        if (setLogHook.HasValue)
        {
            setLogHook.Value.Free();
        }

        GC.SuppressFinalize(this);
    }

    public void RunCallbacks()
    {
        Result res = Methods.RunCallbacks(MethodsPtr);
        if (res != Result.Ok)
        {
            throw new ResultException(res);
        }
    }

    [MonoPInvokeCallback]
    private static void SetLogHookCallbackImpl(IntPtr ptr, LogLevel level, string message)
    {
        GCHandle h = GCHandle.FromIntPtr(ptr);
        SetLogHookHandler callback = (SetLogHookHandler)h.Target;
        callback(level, message);
    }

    public void SetLogHook(LogLevel minLevel, SetLogHookHandler callback)
    {
        if (setLogHook.HasValue)
        {
            setLogHook.Value.Free();
        }

        setLogHook = GCHandle.Alloc(callback);
        Methods.SetLogHook(MethodsPtr, minLevel, GCHandle.ToIntPtr(setLogHook.Value), SetLogHookCallbackImpl);
    }

    public ApplicationManager GetApplicationManager()
    {
        return ApplicationManagerInstance ??= new ApplicationManager(Methods.GetApplicationManager(MethodsPtr), ApplicationEventsPtr, ref ApplicationEvents);
    }

    public UserManager GetUserManager()
    {
        return UserManagerInstance ??= new UserManager(Methods.GetUserManager(MethodsPtr), UserEventsPtr, ref UserEvents);
    }

    public ImageManager GetImageManager()
    {
        return ImageManagerInstance ??= new ImageManager(Methods.GetImageManager(MethodsPtr), ImageEventsPtr, ref ImageEvents); ;
    }

    public ActivityManager GetActivityManager()
    {
        return ActivityManagerInstance ??= new ActivityManager(Methods.GetActivityManager(MethodsPtr), ActivityEventsPtr, ref ActivityEvents); ;
    }

    public RelationshipManager GetRelationshipManager()
    {
        return RelationshipManagerInstance ??= new RelationshipManager(Methods.GetRelationshipManager(MethodsPtr), RelationshipEventsPtr, ref RelationshipEvents);
    }

    public LobbyManager GetLobbyManager()
    {
        return LobbyManagerInstance ??= new LobbyManager(Methods.GetLobbyManager(MethodsPtr), LobbyEventsPtr, ref LobbyEvents);
    }

    public NetworkManager GetNetworkManager()
    {
        return NetworkManagerInstance ??= new NetworkManager(Methods.GetNetworkManager(MethodsPtr), NetworkEventsPtr, ref NetworkEvents);
    }

    public OverlayManager GetOverlayManager()
    {
        return OverlayManagerInstance ??= new OverlayManager(Methods.GetOverlayManager(MethodsPtr), OverlayEventsPtr, ref OverlayEvents);
    }

    public StorageManager GetStorageManager()
    {
        return StorageManagerInstance ??= new StorageManager(Methods.GetStorageManager(MethodsPtr), StorageEventsPtr, ref StorageEvents);
    }

    public StoreManager GetStoreManager()
    {
        return StoreManagerInstance ??= new StoreManager(Methods.GetStoreManager(MethodsPtr), StoreEventsPtr, ref StoreEvents);
    }

    public VoiceManager GetVoiceManager()
    {
        return VoiceManagerInstance ??= new VoiceManager(Methods.GetVoiceManager(MethodsPtr), VoiceEventsPtr, ref VoiceEvents);
    }

    public AchievementManager GetAchievementManager()
    {
        return AchievementManagerInstance ??= new AchievementManager(Methods.GetAchievementManager(MethodsPtr), AchievementEventsPtr, ref AchievementEvents);
    }
}
