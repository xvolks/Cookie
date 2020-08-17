package com.ankamagames.dofus.network.messages.game.guild
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GuildCreationResultMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5554;
       
      
      private var _isInitialized:Boolean = false;
      
      public var result:uint = 0;
      
      public function GuildCreationResultMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5554;
      }
      
      public function initGuildCreationResultMessage(param1:uint = 0) : GuildCreationResultMessage
      {
         this.result = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.result = 0;
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
         this.serializeAs_GuildCreationResultMessage(param1);
      }
      
      public function serializeAs_GuildCreationResultMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.result);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GuildCreationResultMessage(param1);
      }
      
      public function deserializeAs_GuildCreationResultMessage(param1:ICustomDataInput) : void
      {
         this._resultFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GuildCreationResultMessage(param1);
      }
      
      public function deserializeAsyncAs_GuildCreationResultMessage(param1:FuncTree) : void
      {
         param1.addChild(this._resultFunc);
      }
      
      private function _resultFunc(param1:ICustomDataInput) : void
      {
         this.result = param1.readByte();
         if(this.result < 0)
         {
            throw new Error("Forbidden value (" + this.result + ") on element of GuildCreationResultMessage.result.");
         }
      }
   }
}
