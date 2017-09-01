package com.ankamagames.dofus.network.messages.game.tinsel
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class OrnamentSelectRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6374;
       
      
      private var _isInitialized:Boolean = false;
      
      public var ornamentId:uint = 0;
      
      public function OrnamentSelectRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6374;
      }
      
      public function initOrnamentSelectRequestMessage(param1:uint = 0) : OrnamentSelectRequestMessage
      {
         this.ornamentId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.ornamentId = 0;
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
         this.serializeAs_OrnamentSelectRequestMessage(param1);
      }
      
      public function serializeAs_OrnamentSelectRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.ornamentId < 0)
         {
            throw new Error("Forbidden value (" + this.ornamentId + ") on element ornamentId.");
         }
         param1.writeVarShort(this.ornamentId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_OrnamentSelectRequestMessage(param1);
      }
      
      public function deserializeAs_OrnamentSelectRequestMessage(param1:ICustomDataInput) : void
      {
         this._ornamentIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_OrnamentSelectRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_OrnamentSelectRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._ornamentIdFunc);
      }
      
      private function _ornamentIdFunc(param1:ICustomDataInput) : void
      {
         this.ornamentId = param1.readVarUhShort();
         if(this.ornamentId < 0)
         {
            throw new Error("Forbidden value (" + this.ornamentId + ") on element of OrnamentSelectRequestMessage.ornamentId.");
         }
      }
   }
}
