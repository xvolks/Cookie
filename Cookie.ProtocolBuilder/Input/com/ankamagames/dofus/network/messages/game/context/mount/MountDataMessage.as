package com.ankamagames.dofus.network.messages.game.context.mount
{
   import com.ankamagames.dofus.network.types.game.mount.MountClientData;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class MountDataMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5973;
       
      
      private var _isInitialized:Boolean = false;
      
      public var mountData:MountClientData;
      
      private var _mountDatatree:FuncTree;
      
      public function MountDataMessage()
      {
         this.mountData = new MountClientData();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5973;
      }
      
      public function initMountDataMessage(param1:MountClientData = null) : MountDataMessage
      {
         this.mountData = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.mountData = new MountClientData();
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_MountDataMessage(param1);
      }
      
      public function serializeAs_MountDataMessage(param1:ICustomDataOutput) : void
      {
         this.mountData.serializeAs_MountClientData(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MountDataMessage(param1);
      }
      
      public function deserializeAs_MountDataMessage(param1:ICustomDataInput) : void
      {
         this.mountData = new MountClientData();
         this.mountData.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MountDataMessage(param1);
      }
      
      public function deserializeAsyncAs_MountDataMessage(param1:FuncTree) : void
      {
         this._mountDatatree = param1.addChild(this._mountDatatreeFunc);
      }
      
      private function _mountDatatreeFunc(param1:ICustomDataInput) : void
      {
         this.mountData = new MountClientData();
         this.mountData.deserializeAsync(this._mountDatatree);
      }
   }
}
