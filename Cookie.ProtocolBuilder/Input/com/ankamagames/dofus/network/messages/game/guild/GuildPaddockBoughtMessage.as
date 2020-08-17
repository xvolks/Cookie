package com.ankamagames.dofus.network.messages.game.guild
{
   import com.ankamagames.dofus.network.types.game.paddock.PaddockContentInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GuildPaddockBoughtMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5952;
       
      
      private var _isInitialized:Boolean = false;
      
      public var paddockInfo:PaddockContentInformations;
      
      private var _paddockInfotree:FuncTree;
      
      public function GuildPaddockBoughtMessage()
      {
         this.paddockInfo = new PaddockContentInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5952;
      }
      
      public function initGuildPaddockBoughtMessage(param1:PaddockContentInformations = null) : GuildPaddockBoughtMessage
      {
         this.paddockInfo = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.paddockInfo = new PaddockContentInformations();
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
         this.serializeAs_GuildPaddockBoughtMessage(param1);
      }
      
      public function serializeAs_GuildPaddockBoughtMessage(param1:ICustomDataOutput) : void
      {
         this.paddockInfo.serializeAs_PaddockContentInformations(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GuildPaddockBoughtMessage(param1);
      }
      
      public function deserializeAs_GuildPaddockBoughtMessage(param1:ICustomDataInput) : void
      {
         this.paddockInfo = new PaddockContentInformations();
         this.paddockInfo.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GuildPaddockBoughtMessage(param1);
      }
      
      public function deserializeAsyncAs_GuildPaddockBoughtMessage(param1:FuncTree) : void
      {
         this._paddockInfotree = param1.addChild(this._paddockInfotreeFunc);
      }
      
      private function _paddockInfotreeFunc(param1:ICustomDataInput) : void
      {
         this.paddockInfo = new PaddockContentInformations();
         this.paddockInfo.deserializeAsync(this._paddockInfotree);
      }
   }
}
