// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/like.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace like.microservice {
  public static partial class likeGrpc
  {
    static readonly string __ServiceName = "like.likeGrpc";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::like.microservice.CountLikeByCommentRequest> __Marshaller_like_CountLikeByCommentRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::like.microservice.CountLikeByCommentRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::like.microservice.CountLikeByCommentResponse> __Marshaller_like_CountLikeByCommentResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::like.microservice.CountLikeByCommentResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::like.microservice.CountLikeByPostRequest> __Marshaller_like_CountLikeByPostRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::like.microservice.CountLikeByPostRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::like.microservice.CountLikeByPostResponse> __Marshaller_like_CountLikeByPostResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::like.microservice.CountLikeByPostResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::like.microservice.DeleteLikeByPostRequest> __Marshaller_like_DeleteLikeByPostRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::like.microservice.DeleteLikeByPostRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::like.microservice.DeleteLikeByPostResponse> __Marshaller_like_DeleteLikeByPostResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::like.microservice.DeleteLikeByPostResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::like.microservice.DeleteLikeByCommentRequest> __Marshaller_like_DeleteLikeByCommentRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::like.microservice.DeleteLikeByCommentRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::like.microservice.DeleteLikeByCommentResponse> __Marshaller_like_DeleteLikeByCommentResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::like.microservice.DeleteLikeByCommentResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::like.microservice.CreateLikeRequest> __Marshaller_like_CreateLikeRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::like.microservice.CreateLikeRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::like.microservice.CreateLikeResponse> __Marshaller_like_CreateLikeResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::like.microservice.CreateLikeResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::like.microservice.CountLikeByCommentRequest, global::like.microservice.CountLikeByCommentResponse> __Method_CountLikeByComment = new grpc::Method<global::like.microservice.CountLikeByCommentRequest, global::like.microservice.CountLikeByCommentResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CountLikeByComment",
        __Marshaller_like_CountLikeByCommentRequest,
        __Marshaller_like_CountLikeByCommentResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::like.microservice.CountLikeByPostRequest, global::like.microservice.CountLikeByPostResponse> __Method_CountLikeByPost = new grpc::Method<global::like.microservice.CountLikeByPostRequest, global::like.microservice.CountLikeByPostResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CountLikeByPost",
        __Marshaller_like_CountLikeByPostRequest,
        __Marshaller_like_CountLikeByPostResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::like.microservice.DeleteLikeByPostRequest, global::like.microservice.DeleteLikeByPostResponse> __Method_DeleteLikeByPost = new grpc::Method<global::like.microservice.DeleteLikeByPostRequest, global::like.microservice.DeleteLikeByPostResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteLikeByPost",
        __Marshaller_like_DeleteLikeByPostRequest,
        __Marshaller_like_DeleteLikeByPostResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::like.microservice.DeleteLikeByCommentRequest, global::like.microservice.DeleteLikeByCommentResponse> __Method_DeleteLikeByComment = new grpc::Method<global::like.microservice.DeleteLikeByCommentRequest, global::like.microservice.DeleteLikeByCommentResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteLikeByComment",
        __Marshaller_like_DeleteLikeByCommentRequest,
        __Marshaller_like_DeleteLikeByCommentResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::like.microservice.CreateLikeRequest, global::like.microservice.CreateLikeResponse> __Method_CreateLike = new grpc::Method<global::like.microservice.CreateLikeRequest, global::like.microservice.CreateLikeResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateLike",
        __Marshaller_like_CreateLikeRequest,
        __Marshaller_like_CreateLikeResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::like.microservice.LikeReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of likeGrpc</summary>
    [grpc::BindServiceMethod(typeof(likeGrpc), "BindService")]
    public abstract partial class likeGrpcBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::like.microservice.CountLikeByCommentResponse> CountLikeByComment(global::like.microservice.CountLikeByCommentRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::like.microservice.CountLikeByPostResponse> CountLikeByPost(global::like.microservice.CountLikeByPostRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::like.microservice.DeleteLikeByPostResponse> DeleteLikeByPost(global::like.microservice.DeleteLikeByPostRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::like.microservice.DeleteLikeByCommentResponse> DeleteLikeByComment(global::like.microservice.DeleteLikeByCommentRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::like.microservice.CreateLikeResponse> CreateLike(global::like.microservice.CreateLikeRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(likeGrpcBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_CountLikeByComment, serviceImpl.CountLikeByComment)
          .AddMethod(__Method_CountLikeByPost, serviceImpl.CountLikeByPost)
          .AddMethod(__Method_DeleteLikeByPost, serviceImpl.DeleteLikeByPost)
          .AddMethod(__Method_DeleteLikeByComment, serviceImpl.DeleteLikeByComment)
          .AddMethod(__Method_CreateLike, serviceImpl.CreateLike).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, likeGrpcBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_CountLikeByComment, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::like.microservice.CountLikeByCommentRequest, global::like.microservice.CountLikeByCommentResponse>(serviceImpl.CountLikeByComment));
      serviceBinder.AddMethod(__Method_CountLikeByPost, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::like.microservice.CountLikeByPostRequest, global::like.microservice.CountLikeByPostResponse>(serviceImpl.CountLikeByPost));
      serviceBinder.AddMethod(__Method_DeleteLikeByPost, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::like.microservice.DeleteLikeByPostRequest, global::like.microservice.DeleteLikeByPostResponse>(serviceImpl.DeleteLikeByPost));
      serviceBinder.AddMethod(__Method_DeleteLikeByComment, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::like.microservice.DeleteLikeByCommentRequest, global::like.microservice.DeleteLikeByCommentResponse>(serviceImpl.DeleteLikeByComment));
      serviceBinder.AddMethod(__Method_CreateLike, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::like.microservice.CreateLikeRequest, global::like.microservice.CreateLikeResponse>(serviceImpl.CreateLike));
    }

  }
}
#endregion
