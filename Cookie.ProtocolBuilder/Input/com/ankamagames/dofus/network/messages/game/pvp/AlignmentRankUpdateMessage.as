package com.ankamagames.dofus.network.messages.game.pvp
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AlignmentRankUpdateMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6058;
       
      
      private var _isInitialized:Boolean = false;
      
      public var alignmentRank:uint = 0;
      
      public var verbose:Boolean = false;
      
      public function AlignmentRankUpdateMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6058;
      }
      
      public function initAlignmentRankUpdateMessage(param1:uint = 0, param2:Boolean = false) : AlignmentRankUpdateMessage
      {
         this.alignmentRank = param1;
         this.verbose = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.alignmentRank = 0;
         this.verbose = false;
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
         this.serializeAs_AlignmentRankUpdateMessage(param1);
      }
      
      public function serializeAs_AlignmentRankUpdateMessage(param1:ICustomDataOutput) : void
      {
         if(this.alignmentRank < 0)
         {
            throw new Error("Forbidden value (" + this.alignmentRank + ") on element alignmentRank.");
         }
         param1.writeByte(this.alignmentRank);
         param1.writeBoolean(this.verbose);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AlignmentRankUpdateMessage(param1);
      }
      
      public function deserializeAs_AlignmentRankUpdateMessage(param1:ICustomDataInput) : void
      {
         this._alignmentRankFunc(param1);
         this._verboseFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AlignmentRankUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_AlignmentRankUpdateMessage(param1:FuncTree) : void
      {
         param1.addChild(this._alignmentRankFunc);
         param1.addChild(this._verboseFunc);
      }
      
      private function _alignmentRankFunc(param1:ICustomDataInput) : void
      {
         this.alignmentRank = param1.readByte();
         if(this.alignmentRank < 0)
         {
            throw new Error("Forbidden value (" + this.alignmentRank + ") on element of AlignmentRankUpdateMessage.alignmentRank.");
         }
      }
      
      private function _verboseFunc(param1:ICustomDataInput) : void
      {
         this.verbose = param1.readBoolean();
      }
   }
}
