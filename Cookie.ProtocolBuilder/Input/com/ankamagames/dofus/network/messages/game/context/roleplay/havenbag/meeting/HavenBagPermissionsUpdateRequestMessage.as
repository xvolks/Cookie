package com.ankamagames.dofus.network.messages.game.context.roleplay.havenbag.meeting
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class HavenBagPermissionsUpdateRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6714;
       
      
      private var _isInitialized:Boolean = false;
      
      public var permissions:uint = 0;
      
      public function HavenBagPermissionsUpdateRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6714;
      }
      
      public function initHavenBagPermissionsUpdateRequestMessage(param1:uint = 0) : HavenBagPermissionsUpdateRequestMessage
      {
         this.permissions = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.permissions = 0;
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
         this.serializeAs_HavenBagPermissionsUpdateRequestMessage(param1);
      }
      
      public function serializeAs_HavenBagPermissionsUpdateRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.permissions < 0)
         {
            throw new Error("Forbidden value (" + this.permissions + ") on element permissions.");
         }
         param1.writeInt(this.permissions);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HavenBagPermissionsUpdateRequestMessage(param1);
      }
      
      public function deserializeAs_HavenBagPermissionsUpdateRequestMessage(param1:ICustomDataInput) : void
      {
         this._permissionsFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HavenBagPermissionsUpdateRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_HavenBagPermissionsUpdateRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._permissionsFunc);
      }
      
      private function _permissionsFunc(param1:ICustomDataInput) : void
      {
         this.permissions = param1.readInt();
         if(this.permissions < 0)
         {
            throw new Error("Forbidden value (" + this.permissions + ") on element of HavenBagPermissionsUpdateRequestMessage.permissions.");
         }
      }
   }
}
