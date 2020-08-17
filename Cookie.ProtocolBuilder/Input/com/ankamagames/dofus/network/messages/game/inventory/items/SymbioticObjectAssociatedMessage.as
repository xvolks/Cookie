package com.ankamagames.dofus.network.messages.game.inventory.items
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class SymbioticObjectAssociatedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6527;
       
      
      private var _isInitialized:Boolean = false;
      
      public var hostUID:uint = 0;
      
      public function SymbioticObjectAssociatedMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6527;
      }
      
      public function initSymbioticObjectAssociatedMessage(param1:uint = 0) : SymbioticObjectAssociatedMessage
      {
         this.hostUID = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.hostUID = 0;
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
         this.serializeAs_SymbioticObjectAssociatedMessage(param1);
      }
      
      public function serializeAs_SymbioticObjectAssociatedMessage(param1:ICustomDataOutput) : void
      {
         if(this.hostUID < 0)
         {
            throw new Error("Forbidden value (" + this.hostUID + ") on element hostUID.");
         }
         param1.writeVarInt(this.hostUID);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_SymbioticObjectAssociatedMessage(param1);
      }
      
      public function deserializeAs_SymbioticObjectAssociatedMessage(param1:ICustomDataInput) : void
      {
         this._hostUIDFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_SymbioticObjectAssociatedMessage(param1);
      }
      
      public function deserializeAsyncAs_SymbioticObjectAssociatedMessage(param1:FuncTree) : void
      {
         param1.addChild(this._hostUIDFunc);
      }
      
      private function _hostUIDFunc(param1:ICustomDataInput) : void
      {
         this.hostUID = param1.readVarUhInt();
         if(this.hostUID < 0)
         {
            throw new Error("Forbidden value (" + this.hostUID + ") on element of SymbioticObjectAssociatedMessage.hostUID.");
         }
      }
   }
}
