package com.ankamagames.dofus.network.messages.game.guest
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GuestModeMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6505;
       
      
      private var _isInitialized:Boolean = false;
      
      public var active:Boolean = false;
      
      public function GuestModeMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6505;
      }
      
      public function initGuestModeMessage(param1:Boolean = false) : GuestModeMessage
      {
         this.active = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.active = false;
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
         this.serializeAs_GuestModeMessage(param1);
      }
      
      public function serializeAs_GuestModeMessage(param1:ICustomDataOutput) : void
      {
         param1.writeBoolean(this.active);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GuestModeMessage(param1);
      }
      
      public function deserializeAs_GuestModeMessage(param1:ICustomDataInput) : void
      {
         this._activeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GuestModeMessage(param1);
      }
      
      public function deserializeAsyncAs_GuestModeMessage(param1:FuncTree) : void
      {
         param1.addChild(this._activeFunc);
      }
      
      private function _activeFunc(param1:ICustomDataInput) : void
      {
         this.active = param1.readBoolean();
      }
   }
}
