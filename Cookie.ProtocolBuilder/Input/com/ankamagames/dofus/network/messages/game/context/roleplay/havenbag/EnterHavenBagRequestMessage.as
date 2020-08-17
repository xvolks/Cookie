package com.ankamagames.dofus.network.messages.game.context.roleplay.havenbag
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class EnterHavenBagRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6636;
       
      
      private var _isInitialized:Boolean = false;
      
      public var havenBagOwner:Number = 0;
      
      public function EnterHavenBagRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6636;
      }
      
      public function initEnterHavenBagRequestMessage(param1:Number = 0) : EnterHavenBagRequestMessage
      {
         this.havenBagOwner = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.havenBagOwner = 0;
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
         this.serializeAs_EnterHavenBagRequestMessage(param1);
      }
      
      public function serializeAs_EnterHavenBagRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.havenBagOwner < 0 || this.havenBagOwner > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.havenBagOwner + ") on element havenBagOwner.");
         }
         param1.writeVarLong(this.havenBagOwner);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_EnterHavenBagRequestMessage(param1);
      }
      
      public function deserializeAs_EnterHavenBagRequestMessage(param1:ICustomDataInput) : void
      {
         this._havenBagOwnerFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_EnterHavenBagRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_EnterHavenBagRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._havenBagOwnerFunc);
      }
      
      private function _havenBagOwnerFunc(param1:ICustomDataInput) : void
      {
         this.havenBagOwner = param1.readVarUhLong();
         if(this.havenBagOwner < 0 || this.havenBagOwner > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.havenBagOwner + ") on element of EnterHavenBagRequestMessage.havenBagOwner.");
         }
      }
   }
}
